using cqrs.framework.Interfaces;

namespace cqrs.framework.Queries.Users
{
    public class GetUserById : IQuery
    {
        public int Id { get; set; }
    }

    public class GetUserByIdResult : IQueryResult
    {
        /*
         * When implementing your own query result, this could contain a UserDTO or similar
         */
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }

    public class GetUserByIdHandler : IQueryHandler<GetUserById, GetUserByIdResult>
    {
        public async Task<GetUserByIdResult> HandleAsync(GetUserById query)
        {
            //Return dummy data. In a production setting, this would be connecting to your db or service to obtain data
            return new GetUserByIdResult
            {
                FirstName = "This is an example",
                LastName = "Still an example",
                Email = "example@gmail.com"
            };
        }
    }
}
