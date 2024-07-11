using Microsoft.AspNetCore.Cors.Infrastructure;

namespace UserPortal.Options;

internal class CorsOptions
{
    public string[] HttpMethods { get; set; } = [];
    public string[] AllowedHosts { get; set; } = [];

    public string[] AllowedHeaders { get; set; } = [];

    public static CorsOptions FromConfiguration(IConfiguration configuration)
    {
        var section = configuration.GetSection("CorsSettings");
        var o = new CorsOptions();
        section.Bind(o);

        return o;
    }
}


internal static class CorsBuilderExtensions
{
    internal static CorsPolicyBuilder ConfigureCorsOptions(this CorsPolicyBuilder builder, IWebHostEnvironment env, IConfiguration configuration)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        }
        else
        {
            var corsSettings = CorsOptions
                .FromConfiguration(configuration);

            if (corsSettings.HttpMethods.Length > 0)
            {
                builder.WithMethods(corsSettings.HttpMethods);
            }
            else
            {
                builder.AllowAnyMethod();
            }

            if (corsSettings.AllowedHosts.Length > 0)
            {
                builder.WithOrigins(corsSettings.AllowedHosts);
            }
            else
            {
                builder.AllowAnyMethod();
            }

            if (corsSettings.AllowedHeaders.Length > 0)
            {
                builder.WithHeaders(corsSettings.AllowedHeaders);
            }
            else
            {
                builder.AllowAnyHeader();
            }
        }

        return builder;
    }
}