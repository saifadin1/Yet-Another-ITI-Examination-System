using System;
using System.Collections.Generic;
using System.Text;
using Yet_Another_Examination_System.Domain.Collections;
using Yet_Another_Examination_System.Domain.Entities;

namespace Yet_Another_Examination_System.Domain.Questions
{
    internal abstract class Question : ICloneable
    {
        
        public string Body { get; set; }
        public int Mark { get; set; }    
        public string Header { get; set; }
        public AnswerList Answers;
        public Answer CorrectAnswer { get; set; }
        public Question(string body, int mark, string header, Answer correctAnswer)
        {
                
            Body = body;
            Mark = mark;
            Header = header;
            CorrectAnswer = correctAnswer;
        }

        public abstract void Display(); 
        public  abstract bool CheckAnswer(Answer studentAnswer);

        public override string ToString()
        {
            return Body;
        }

        override public bool Equals(object obj)
        {
            if (obj is Question otherQuestion)
            {
                return Body == otherQuestion.Body &&
                        Mark == otherQuestion.Mark &&
                        Header == otherQuestion.Header &&
                        CorrectAnswer.Equals(otherQuestion.CorrectAnswer);
            }
            return false;
        }

        override public int GetHashCode()
        {
            return HashCode.Combine(Body, Mark, Header, CorrectAnswer);
        }

        public object Clone()
        {
            Question clonedQuestion = (Question)this.MemberwiseClone();
            clonedQuestion.CorrectAnswer = (Answer)this.CorrectAnswer.Clone();
            clonedQuestion.Answers = (AnswerList)this.Answers.Clone();

            return clonedQuestion;
        }
    }
}
