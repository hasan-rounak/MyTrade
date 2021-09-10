using FluentValidation;
using MyTrade.Business.Command;

namespace MyTrade.Business.Validator
{
    public class UpdateTradeCommandValidator : AbstractValidator<UpdateTradeCommand>
    {
        public UpdateTradeCommandValidator()
        {

        }
    }
}
