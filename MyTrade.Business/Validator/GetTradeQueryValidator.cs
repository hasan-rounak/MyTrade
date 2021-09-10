using FluentValidation;
using MyTrade.Business.Query;

namespace MyTrade.Business.Validator
{
    public class GetTradeQueryValidator : AbstractValidator<GetTradeQuery>
    {
        public GetTradeQueryValidator()
        {

        }
    }
}
