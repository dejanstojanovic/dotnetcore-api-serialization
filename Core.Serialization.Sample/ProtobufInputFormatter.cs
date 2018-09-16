using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;
using ProtoBuf;

namespace Core.Serialization.Sample
{
    public class ProtobufInputFormatter : InputFormatter
    {
        public ProtobufInputFormatter()
        {
            this.SupportedMediaTypes.Clear();
            this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-protobuf"));
        }

        public override bool CanRead(InputFormatterContext context)
        {
            return base.CanRead(context);
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var type = context.ModelType;
            var request = context.HttpContext.Request;
            MediaTypeHeaderValue requestContentType = null;
            MediaTypeHeaderValue.TryParse(request.ContentType, out requestContentType);


            object result = Serializer.Deserialize(type, context.HttpContext.Request.Body);
            return InputFormatterResult.SuccessAsync(result);
        }
    }
}
