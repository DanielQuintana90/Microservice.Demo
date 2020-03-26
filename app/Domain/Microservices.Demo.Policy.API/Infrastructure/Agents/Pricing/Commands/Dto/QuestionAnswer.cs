using Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing.Commands.Dto
{
    public abstract class QuestionAnswer
    {
        public string QuestionCode { get; set; }
        public abstract QuestionType QuestionType { get; }
        public abstract object GetAnswer();

    }

    public abstract class QuestionAnswer<T> : QuestionAnswer
    {
        public T Answer { get; set; }

        public override object GetAnswer() => Answer;
    }

    public class TextQuestionAnswer : QuestionAnswer<string>
    {
        public override QuestionType QuestionType => QuestionType.Text;
    }


    public class NumericQuestionAnswer : QuestionAnswer<decimal>
    {
        public override QuestionType QuestionType => QuestionType.Number;
    }

    public class ChoiceQuestionAnswer : QuestionAnswer<string>
    {
        public override QuestionType QuestionType => QuestionType.Choice;
    }
}
