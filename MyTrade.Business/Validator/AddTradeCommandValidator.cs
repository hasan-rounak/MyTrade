using FluentValidation;
using MyTrade.Business.Command;

namespace MyTrade.Business.Validator
{
    public class AddTradeCommandValidator : AbstractValidator<AddTradeCommand>
    {
        public AddTradeCommandValidator()
        {

        }
    }
}
