using FluentValidation;
using MyTrade.Business.Query;

namespace MyTrade.Business.Validator
{
    public class GetAllTradesQueryValidator : AbstractValidator<GetAllTradesQuery>
    {
        public GetAllTradesQueryValidator()
        {

        }
    }
}
