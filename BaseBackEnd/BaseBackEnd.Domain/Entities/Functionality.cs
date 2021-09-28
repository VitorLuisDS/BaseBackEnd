using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class Functionality : EntityAuditStatusBase
    {
        public int Id { get; }
        public CodeVO Code { get; private set; }
        public NameVO Name { get; private set; }
        public DescriptionVO Description { get; private set; }

        private ICollection<Page> _pages { get; set; }
        public IReadOnlyCollection<Page> Pages { get { return _pages.ToArray(); } }

        private ICollection<Profile> _userProfiles { get; set; }
        public IReadOnlyCollection<Profile> UserProfiles { get { return _userProfiles.ToArray(); } }

        public Functionality(CodeVO code, NameVO name, DescriptionVO description)
        {
            Code = code;
            Name = name;
            Description = description;

            AddNotifications(code, name, description);
        }

        public void AddPage(Page page)
        {
            var pageAlreadyExists = _pages
                .Any(u => u.Id == page.Id);

            AddNotifications(new Contract<Page>()
                .IsFalse(pageAlreadyExists, $"{nameof(Functionality)}.{nameof(Page)}", $"{nameof(Functionality)} already has this {nameof(Page)}"));

            if (IsValid)
            {
                _pages.Add(page);
                if (!page.Functionalities.Contains(this))
                    page.AddFunctionality(this);
            }
        }

        public void AddProfile(Profile profile)
        {
            var profileAlreadyExists = _userProfiles
                .Any(up => up.Id == profile.Id);

            AddNotifications(new Contract<User>()
                .IsFalse(profileAlreadyExists, $"{nameof(Functionality)}.{nameof(UserProfiles)}", $"{nameof(Functionality)} already has this {nameof(Profile)}"));

            if (IsValid)
            {
                _userProfiles.Add(profile);

                if (!profile.Functionalities.Contains(this))
                    profile.AddFunctionality(this);
            }
        }
    }
}
