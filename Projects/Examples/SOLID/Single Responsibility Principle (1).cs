namespace SOLID.SRP
{
    //Bad example 
    public class UserBad
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public void SaveUser()
        {
            // Save user to the database
        }

        public void SendEmail(string message)
        {
            // Send email to user
        }
    }

    // Good example
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }

    public class UserRepository
    {
        public void SaveUser(User user)
        {
            // Save user to the database
        }
        public void UpdateUser(Guid userId, User user)
        {
        }
        public void DeleteUser(Guid userId)
        {
        }
    }

    public class EmailService
    {
        public void SendEmail(string emailAddress, string message)
        {
            // Send email to user
        }
    }
}
