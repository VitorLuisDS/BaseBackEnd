using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class Module : EntityAuditStatusBase
    {
        public int Id { get; }
        public CodeVO Code { get; private set; }
        public NameVO Name { get; private set; }
        public DescriptionVO Description { get; private set; }

        private ICollection<Page> _pages { get; set; }
        public IReadOnlyCollection<Page> Pages { get { return _pages.ToArray(); } }

        public Module(CodeVO code, NameVO name, DescriptionVO description)
        {
            Code = code;
            Name = name;
            Description = description;

            AddNotifications(code, name, description);
        }

        public void AddPage(Page page)
        {
            bool pageAlreadyExists = _pages
                .Any(up => up.Id == page.Id);

            AddNotifications(new Contract<Page>()
                .IsFalse(pageAlreadyExists, $"{nameof(Module)}.{nameof(Pages)}", $"{nameof(Module)} already has this {nameof(Page)}"));

            if (IsValid)
            {
                _pages.Add(page);
                if (page.Module != this)
                    page.SetModule(this);
            }
        }
    }
}
