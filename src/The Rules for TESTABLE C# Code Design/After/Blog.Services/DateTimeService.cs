namespace Blog.Services
{
    using System;

    public class DateTimeService : IDateTimeService
    {
        public DateTime Now() => DateTime.UtcNow;
    }
}
