using System.ComponentModel;

namespace Esperanza.Core.Models
{
    public class Errors : Entity
    {
        public Errors(string message, string stackTrace)
        {
            Guid = System.Guid.NewGuid();
            Deleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            CreatedBy = new System.Guid();
            UpdatedBy = new System.Guid();
            Message = message;
            StackTrace = stackTrace;
        }

        public string? Message { get; set; }
        public string? StackTrace { get; set; }


        [Description("ignore")]
        public static string InsertError
        {
            get
            {
                return @"INSERT INTO Errors (Guid, Deleted, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy, Message, StackTrace) VALUES (@Guid, @Deleted, @CreatedAt, @UpdatedAt, @CreatedBy, @UpdatedBy, @Message, @StackTrace);";
            }
        }
    }
}
