﻿using aspPopravni.Application.DTO;
using aspPopravni.Application.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.Application.Queries
{
    public interface IGetBooks : IQuery<PagedResponseDTO<BookDTO>, SearchBookDTO>
    {
    }
}
