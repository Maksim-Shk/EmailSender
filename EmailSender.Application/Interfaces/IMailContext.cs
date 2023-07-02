using Microsoft.EntityFrameworkCore;
using EmailSender.Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EmailSender.Application.Interfaces
{
    public interface IMailContext
    {
        //DbSet<User> Users { get; set; }
        DbSet<Mail> Mails { get; set; }
        DbSet<SentMail> SentMails { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DatabaseFacade Database { get { return this.Database; } }
    }
}
