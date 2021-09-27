using BaseBackEnd.Security.Domain.Entities;
using BaseBackEnd.Security.Domain.Factory.Entities.Interfaces;
using BaseBackEnd.Security.Domain.Factory.ValueObjects.Interfaces;
using BaseBackEnd.Security.Domain.ValueObjects;

namespace BaseBackEnd.Security.Domain.Factory.Entities
{
    public class UserFactory : IUserFactory
    {
        private readonly INameVOFactory _nameVOFactory;
        private readonly ILoginVOFactory _loginVOFactory;
        private readonly IPasswordVOFactory _passwordVOFactory;

        public UserFactory(INameVOFactory nameVOFactory, ILoginVOFactory loginVOFactory, IPasswordVOFactory passwordVOFactory)
        {
            _nameVOFactory = nameVOFactory;
            _loginVOFactory = loginVOFactory;
            _passwordVOFactory = passwordVOFactory;
        }

        public User CreateUser(string name, string login, string password)
        {
            NameVO nameVO = _nameVOFactory.CreateNameVO(name);
            LoginVO loginVO = _loginVOFactory.CreateLoginVO(login);
            PasswordVO passwordVO = _passwordVOFactory.CreatePasswordVO(password);

            User user = new User(nameVO, loginVO, passwordVO);

            return user;
        }
    }
}
