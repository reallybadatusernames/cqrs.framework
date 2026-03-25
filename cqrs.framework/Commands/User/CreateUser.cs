using cqrs.framework.Interfaces;

namespace cqrs.framework.Commands.User
{
    public class CreateUser : ICommand
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }

    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        /*
         * NOTE: This will not typically live next to the command itself since it will be interacting with some service or database
         * This is for demonstration only, but consider moving handlers to your service layer.
        */
        public async Task HandleAsync(CreateUser command)
        {
            //Implement logic
            Console.WriteLine($"User {command.FirstName} {command.LastName} was created");
        }
    }
}
