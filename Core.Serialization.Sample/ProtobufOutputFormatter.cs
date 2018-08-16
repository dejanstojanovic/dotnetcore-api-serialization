using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace Core.Serialization.Sample
{
    public class ProtobufOutputFormatter : OutputFormatter
    {
        public ProtobufOutputFormatter()
        {
            this.SupportedMediaTypes.Clear();

            this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-protobuf"));
            //this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-google-protobuf"));


            
        }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return true;
            //return base.CanWriteResult(context);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var resultObject = context.Object;
            byte[] serializedData= new byte[] { };
            var outputStream = new MemoryStream();
            context.HttpContext.Response.Body = outputStream;

            return outputStream.WriteAsync(serializedData, 0, serializedData.Length);
        }
    }
}
