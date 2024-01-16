using Application.Commons.Interfaces;
using Application.Dtos.Requests.Assets;
using Application.Dtos.Responses.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases
{
    public interface IPutAssetsUseCase : IAuthenticatedUseCases<PutAssetsRequest, PutAssetsResponse>
    {
    }

}
