﻿namespace Khala.EventSourcing
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static class EventSourcingExtensions
    {
        public static Task Save<T>(
            this IEventSourcedRepository<T> repository,
            T source,
            CancellationToken cancellationToken)
            where T : class, IEventSourced
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return repository.Save(source, null, cancellationToken);
        }

        public static Task Save<T>(
            this IEventSourcedRepository<T> repository,
            T source,
            Guid? correlationId)
            where T : class, IEventSourced
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return repository.Save(source, correlationId, CancellationToken.None);
        }

        public static Task Save<T>(
            this IEventSourcedRepository<T> repository,
            T source)
            where T : class, IEventSourced
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return repository.Save(source, null, CancellationToken.None);
        }

        public static Task<T> Find<T>(
            this IEventSourcedRepository<T> repository,
            Guid sourceId)
            where T : class, IEventSourced
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (sourceId == Guid.Empty)
            {
                throw new ArgumentException(
                    $"{nameof(sourceId)} cannot be empty.", nameof(sourceId));
            }

            return repository.Find(sourceId, CancellationToken.None);
        }
    }
}
