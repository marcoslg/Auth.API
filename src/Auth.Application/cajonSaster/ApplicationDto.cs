using System.Collections.Generic;

namespace Auth.Application.cajonSaster
{
    public class ApplicationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<PermisionDto> Permisions { get; set; }

    }
}
