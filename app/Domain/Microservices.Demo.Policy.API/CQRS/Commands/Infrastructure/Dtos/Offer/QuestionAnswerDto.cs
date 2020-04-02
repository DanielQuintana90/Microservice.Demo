using Microservices.Demo.Policy.API.CQRS.Commands.Infrastructure.Dtos.Converters;
using Microservices.Demo.Policy.API.Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.CQRS.Commands.Infrastructure.Dtos.Offer
{
    [JsonConverter(typeof(QuestionAnswerDtoConverter))]
    public abstract class QuestionAnswerDto
    {
        public string QuestionCode { get; set; }
        public abstract QuestionType QuestionType { get; }
        public abstract object GetAnswer();

    }

    public abstract class QuestionAnswer<T> : QuestionAnswerDto
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
        public override QuestionType QuestionType => QuestionType.Numeric;
    }

    public class ChoiceQuestionAnswer : QuestionAnswer<string>
    {
        public override QuestionType QuestionType => QuestionType.Choice;
    }
}
