using BaseBackEnd.Security.Domain.Entities.Base;
using BaseBackEnd.Security.Domain.ValueObjects;
using Flunt.Validations;
using System.Collections.Generic;

namespace BaseBackEnd.Security.Domain.Entities
{
    public class Page : EntityAuditStatusBase
    {
        public int Id { get; }
        public CodeVO Code { get; private set; }
        public NameVO Name { get; private set; }
        public DescriptionVO Description { get; private set; }
        public Module Module { get; private set; }

        private ICollection<Functionality> _functionalities { get; set; }
        public IReadOnlyCollection<Functionality> Functionalities { get { return _functionalities.ToArray(); } }

        public Page(CodeVO code, NameVO name, DescriptionVO description, Module module)
        {
            Code = code;
            Name = name;
            Description = description;
            Module = module;

            AddNotifications(code, name, description, module);
        }

        public void AddFunctionality(Functionality functionality)
        {
            var functionalityAlreadyExists = _functionalities
                .Any(u => u.Id == functionality.Id);

            AddNotifications(new Contract<Functionality>()
                .IsFalse(functionalityAlreadyExists, $"{nameof(Page)}.{nameof(Functionalities)}", $"{nameof(Page)} already has this {nameof(Functionality)}"));

            if (IsValid)
                _functionalities.Add(functionality);
        }
    }
}
