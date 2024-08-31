using MediatR;

namespace BaseCoreExample.Core.Common
{
    /// <summary>
    /// Данный класс обозначает сущность.
    /// Как мы знаем, у каждой сущности должен быть уникальный первичный ключ
    /// Так как мы используем "Экстремальное программирование", выходит, что
    /// хранится все именно так.
    ///
    /// Но для банального поиска по Id, лучше использовать спецификацию.
    /// Также было бы прекрасно переопределить Equals, то так как модели у нас POCO,
    /// то ничего хорошего из этого не выйдет, все выносится в сервисы :\
    ///
    /// DomainEvents -> события сущности для уведомления всех подписчиков об изменении
    /// в stateless очень полезная штука, как может не оказаться на первый
    /// взгляд
    /// </summary>
    /// <typeparam name="TId">Желаемый идентификатор</typeparam>
    public abstract class BaseEntity<TId> : IBaseEntity
        where TId : struct
    {
        private readonly List<INotification> _domainEvents = new List<INotification>();
        public virtual TId Id { get; set; }
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);

        public void RemoveDomainEvent(INotification domainEvent) =>
            _domainEvents.Remove(domainEvent);

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
