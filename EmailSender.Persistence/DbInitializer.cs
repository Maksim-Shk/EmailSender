
namespace EmailSender.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(MailContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
