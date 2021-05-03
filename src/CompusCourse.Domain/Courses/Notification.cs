using CompusCourse.Domain.Common;

using System;

namespace CompusCourse.Domain.Courses
{
    /// <summary>
    /// Represents notification entity
    /// </summary>
    public sealed class Notification : Entity
    {
        /// <summary>
        /// Notification body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Notification creation date
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
    }
}
