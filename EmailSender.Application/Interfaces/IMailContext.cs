using Microsoft.EntityFrameworkCore;
using EmailSender.Domain;

namespace EmailSender.Application.Interfaces
{
    public interface IMailContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Mail> Mails { get; set; }
        DbSet<SentMail> SentMails { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
