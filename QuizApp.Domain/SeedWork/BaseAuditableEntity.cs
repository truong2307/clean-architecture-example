using System;

namespace QuizApp.Domain.SeedWork
{
    public abstract class BaseAuditableEntity : Entity
    {
        public DateTime Created { get; protected set; }

        public string CreatedBy { get; protected set; }

        public DateTime? Updated { get; protected set; }

        public string UpdateddBy { get; protected set; }
    }
}
