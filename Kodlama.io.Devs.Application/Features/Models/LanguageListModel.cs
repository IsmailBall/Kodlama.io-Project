using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Models
{
    public class LanguageListModel : BasePageableModel
    {
        public IList<LanguageListDto> Items { get; set; }
    }
}
