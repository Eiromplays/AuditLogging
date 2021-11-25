// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Extensions/AuditLoggingExtensions.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Builder;
using Eiromplays.AuditLogging.Builder.Interfaces;
using Eiromplays.AuditLogging.Configuration.Options;
using Eiromplays.AuditLogging.Events.Default;
using Eiromplays.AuditLogging.Events.Http;
using Eiromplays.AuditLogging.Events.Interfaces;
using Eiromplays.AuditLogging.Services;
using Eiromplays.AuditLogging.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eiromplays.AuditLogging.Extensions;

public static class DependencyInjection
{
    public static IAuditLoggingBuilder AddAuditLoggingBuilder(this IServiceCollection services)
    {
        return new AuditLoggingBuilder(services);
    }

    public static IAuditLoggingBuilder AddAuditLogging<TAuditLoggerOptions>(this IServiceCollection services, Action<TAuditLoggerOptions>? loggerOptions = default)
        where TAuditLoggerOptions : AuditLoggerOptions, new()
    {
        var builder = services.AddAuditLoggingBuilder();

        var auditLoggerOptions = new TAuditLoggerOptions();
        loggerOptions?.Invoke(auditLoggerOptions);

        builder.Services.AddSingleton(auditLoggerOptions);
        builder.Services.AddTransient<IAuditLogger, AuditLogger>();

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditLogging(this IServiceCollection service,
        Action<AuditLoggerOptions>? loggerOptions = default)
    {
        return service.AddAuditLogging<AuditLoggerOptions>(loggerOptions);
    }

    public static IAuditLoggingBuilder AddDefaultHttpEventData(this IAuditLoggingBuilder builder, Action<AuditHttpSubjectOptions>? subjectOptions = default, Action<AuditHttpActionOptions>? actionOptions = default)
    {
        var auditHttpSubjectOptions = new AuditHttpSubjectOptions();
        subjectOptions?.Invoke(auditHttpSubjectOptions);
        builder.Services.AddSingleton(auditHttpSubjectOptions);

        var auditHttpActionOptions = new AuditHttpActionOptions();
        actionOptions?.Invoke(auditHttpActionOptions);
        builder.Services.AddSingleton(auditHttpActionOptions);

        builder.Services.AddTransient<IAuditSubject, HttpAuditSubject>();
        builder.Services.AddTransient<IAuditAction, HttpAuditAction>();

        return builder;
    }

    public static IAuditLoggingBuilder AddStaticEventSubject(this IAuditLoggingBuilder builder, Action<DefaultAuditSubject> defaultAuditSubject)
    {
        var auditSubject = new DefaultAuditSubject();
        defaultAuditSubject.Invoke(auditSubject);
        builder.Services.AddSingleton<IAuditSubject>(auditSubject);

        return builder;
    }

    public static IAuditLoggingBuilder AddDefaultEventSubject(this IAuditLoggingBuilder builder)
    {
        builder.Services.AddTransient<IAuditSubject, DefaultAuditSubject>();

        return builder;
    }

    public static IAuditLoggingBuilder AddDefaultEventAction(this IAuditLoggingBuilder builder)
    {
        builder.Services.AddTransient<IAuditAction, DefaultAuditAction>();

        return builder;
    }

    public static IAuditLoggingBuilder AddDefaultEventData(this IAuditLoggingBuilder builder)
    {
        builder.Services.AddTransient<IAuditSubject, DefaultAuditSubject>();
        builder.Services.AddTransient<IAuditAction, DefaultAuditAction>();

        return builder;
    }

    public static IAuditLoggingBuilder AddEventData<TEventSubject, TEventAction>(this IAuditLoggingBuilder builder)
        where TEventSubject : class, IAuditSubject
        where TEventAction : class, IAuditAction
    {
        builder.Services.AddTransient<IAuditSubject, TEventSubject>();
        builder.Services.AddTransient<IAuditAction, TEventAction>();

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditSinks<TSink1>(this IAuditLoggingBuilder builder)
        where TSink1 : class, IAuditLoggerSink
    {
        builder.Services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink1>(),
        });

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditSinks<TSink1, TSink2>(this IAuditLoggingBuilder builder)
        where TSink1 : class, IAuditLoggerSink
        where TSink2 : class, IAuditLoggerSink
    {
        builder.Services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink1>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink2>()
        });

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditSinks<TSink1, TSink2, TSink3>(this IAuditLoggingBuilder builder)
        where TSink1 : class, IAuditLoggerSink
        where TSink2 : class, IAuditLoggerSink
        where TSink3 : class, IAuditLoggerSink
    {
        builder.Services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink1>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink2>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink3>()
        });

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditSinks<TSink1, TSink2, TSink3, TSink4>(this IAuditLoggingBuilder builder)
        where TSink1 : class, IAuditLoggerSink
        where TSink2 : class, IAuditLoggerSink
        where TSink3 : class, IAuditLoggerSink
        where TSink4 : class, IAuditLoggerSink
    {
        builder.Services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink1>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink2>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink3>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink4>()
        });

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditSinks<TSink1, TSink2, TSink3, TSink4, TSink5>(this IAuditLoggingBuilder builder)
        where TSink1 : class, IAuditLoggerSink
        where TSink2 : class, IAuditLoggerSink
        where TSink3 : class, IAuditLoggerSink
        where TSink4 : class, IAuditLoggerSink
        where TSink5 : class, IAuditLoggerSink
    {
        builder.Services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink1>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink2>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink3>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink4>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink5>()
        });

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditSinks<TSink1, TSink2, TSink3, TSink4, TSink5, TSink6>(this IAuditLoggingBuilder builder)
        where TSink1 : class, IAuditLoggerSink
        where TSink2 : class, IAuditLoggerSink
        where TSink3 : class, IAuditLoggerSink
        where TSink4 : class, IAuditLoggerSink
        where TSink5 : class, IAuditLoggerSink
        where TSink6 : class, IAuditLoggerSink
    {
        builder.Services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink1>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink2>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink3>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink4>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink5>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink6>()
        });

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditSinks<TSink1, TSink2, TSink3, TSink4, TSink5, TSink6, TSink7>(this IAuditLoggingBuilder builder)
        where TSink1 : class, IAuditLoggerSink
        where TSink2 : class, IAuditLoggerSink
        where TSink3 : class, IAuditLoggerSink
        where TSink4 : class, IAuditLoggerSink
        where TSink5 : class, IAuditLoggerSink
        where TSink6 : class, IAuditLoggerSink
        where TSink7 : class, IAuditLoggerSink
    {
        builder.Services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink1>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink2>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink3>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink4>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink5>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink6>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink7>()
        });

        return builder;
    }

    public static IAuditLoggingBuilder AddAuditSinks<TSink1, TSink2, TSink3, TSink4, TSink5, TSink6, TSink7, TSink8>(this IAuditLoggingBuilder builder)
        where TSink1 : class, IAuditLoggerSink
        where TSink2 : class, IAuditLoggerSink
        where TSink3 : class, IAuditLoggerSink
        where TSink4 : class, IAuditLoggerSink
        where TSink5 : class, IAuditLoggerSink
        where TSink6 : class, IAuditLoggerSink
        where TSink7 : class, IAuditLoggerSink
        where TSink8 : class, IAuditLoggerSink
    {
        builder.Services.TryAddEnumerable(new[]
        {
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink1>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink2>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink3>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink4>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink5>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink6>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink7>(),
            ServiceDescriptor.Transient<IAuditLoggerSink, TSink8>()
        });

        return builder;
    }
}