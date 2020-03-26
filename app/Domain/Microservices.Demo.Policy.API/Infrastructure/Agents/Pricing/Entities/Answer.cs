using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing.Entities
{
    public abstract class Answer
    {
        public string QuestionCode { get; protected set; }
        public abstract object GetAnswerValue();
    }

    public abstract class Answer<T> : Answer
    {
        public T AnswerValue { get; protected set; }

        public override object GetAnswerValue() => AnswerValue;
    }

    public class TextAnswer : Answer<string>
    {
        public TextAnswer() { } 

        public TextAnswer(string questionCode, string answer)
        {
            this.QuestionCode = questionCode;
            this.AnswerValue = answer;
        }
    }

    public class NumericAnswer : Answer<decimal>
    {
        public NumericAnswer() { }

        public NumericAnswer(string questionCode, decimal answer)
        {
            this.QuestionCode = questionCode;
            this.AnswerValue = answer;
        }
    }

    public class ChoiceAnswer : Answer<string>
    {
        public ChoiceAnswer() { }

        public ChoiceAnswer(string questionCode, string answer)
        {
            this.QuestionCode = questionCode;
            this.AnswerValue = answer;
        }
    }
}
