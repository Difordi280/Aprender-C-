using System.Diagnostics;
using System;


namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Use(async (context,next)  =>
            {
                var sw = Stopwatch.StartNew();
                sw.Start();
                
                await next.Invoke();

                sw.Stop();

                var a=context.Request.Path;

                Console.WriteLine(a);

                Console.WriteLine(sw.Elapsed.ToString());

            });


            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
