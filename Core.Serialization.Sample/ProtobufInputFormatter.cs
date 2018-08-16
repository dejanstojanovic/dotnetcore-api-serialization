using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;

namespace Core.Serialization.Sample
{
    public class ProtobufInputFormatter : InputFormatter
    {
        public ProtobufInputFormatter()
        {

            this.SupportedMediaTypes.Clear();

            this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-protobuf"));
            //this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-google-protobuf"));

        }

        public override bool CanRead(InputFormatterContext context)
        {
            //return base.CanRead(context);
            return true;
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            
            var inputData = context.HttpContext.Request.Body;

            throw new NotImplementedException();
        }
    }
}
