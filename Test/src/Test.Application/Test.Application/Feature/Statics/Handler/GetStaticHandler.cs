using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Feature.Statics.Queries;
using Test.DataAccess.DTOs.Get;
using Test.DataAccess.Repository;

namespace Test.Application.Feature.Statics.Handler;

public class GetStaticHandler : IRequestHandler<GetStaticQueries, StaticGetModel>
{
    private readonly IStaticRepository _staticRepository;
    public GetStaticHandler(IStaticRepository staticRepository)
    {
        _staticRepository = staticRepository;
    }
    public async Task<StaticGetModel> Handle(GetStaticQueries request, CancellationToken cancellationToken)
    {
       var res = await _staticRepository.GetFirstAsync(u => u.id == request.id);
        if (res == null)
        {
            return null;
        }
        var result = new StaticGetModel()
        {
            SubjectId = res.SubjectId,
            NumberOfStudent = res.NumberOfStudent,
            AmountPercentage = res.AmountPercentage,
        };
        return result;
    }
}
