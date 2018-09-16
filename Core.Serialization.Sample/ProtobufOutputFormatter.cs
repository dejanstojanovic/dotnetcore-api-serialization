using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;
using ProtoBuf;

namespace Core.Serialization.Sample
{
    public class ProtobufOutputFormatter : OutputFormatter
    {
        public ProtobufOutputFormatter()
        {
            this.SupportedMediaTypes.Clear();
            this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-protobuf"));           
        }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return base.CanWriteResult(context);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {

            var response = context.HttpContext.Response;

            Serializer.Serialize(response.Body, context.Object);
            return Task.FromResult(response);

        }
    }
}
