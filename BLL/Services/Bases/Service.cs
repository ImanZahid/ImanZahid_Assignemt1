using BLL.DAL;

namespace BLL.Services.Bases
{
    public abstract class Service
    {
        protected readonly DB StudentsDBContext;

        public bool IsSuccessful { get; private set; }

        public string? Message { get; private set; }

        public Service(DB studentsDBContext)
        {
            StudentsDBContext = studentsDBContext;
        }

        public Service Success(string? message)
        {
            IsSuccessful = true;
            Message = message == null ? "ERROR!" : Message;
            return this;
        }

        public Service Error(string? message)
        {
            IsSuccessful = false;
            Message = message == null ? "ERROR!" : Message;
            return this;
        }
    }
}
