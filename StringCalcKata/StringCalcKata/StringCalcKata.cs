using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace StringCalcKata
{
    public class StringCalcKata
    {
        int m_AddCallCount;
        int m_Result;
        char[] m_delimeters;
        string m_calcstring;
        public string m_ErrorMessage;

        public void Add(string v)
        {
            m_AddCallCount++;
            GetDelimiters(v);

            m_Result = -1;
            if (IsEmptyString(m_calcstring))
                m_Result = 0;
            else if (m_calcstring.Length == 1)
                m_Result = int.Parse(v);
            //else if (v.Contains(",") || v.Contains("\n"))
            else
            {
                m_Result = 0;
                m_ErrorMessage = "";
                string[] numbs = m_calcstring.Split(m_delimeters);

                for (int i = 0; i < numbs.Length; i++)
                { 
                    int n = int.Parse(numbs[i]);
                    if (n < 0)
                    {
                        m_ErrorMessage += n + ",";
                    }
                    else if (n < 1001)
                        m_Result += n;
                }

                if (m_ErrorMessage.Length > 0)
                {
                    m_ErrorMessage = "negative numbers not allowed - " + m_ErrorMessage;
                    throw new ApplicationException(m_ErrorMessage);
                }
            }
        }

        private void GetDelimiters(string v)
        {
            if (v.StartsWith("//"))
            {
                int endofdelimeter = v.IndexOf("\n");
                m_delimeters = new char[1];
                m_delimeters[0] = (v.Substring(2, endofdelimeter))[0];
                m_calcstring = v.Substring(endofdelimeter+1);
            }
            else
            {
                m_delimeters = new char[2];
                m_delimeters[0] = ',';
                m_delimeters[1] = '\n';
                m_calcstring = v;
            }
        }

        private bool IsEmptyString(string v)
        {
            if (v == null)
                return false;
            else if (v.Length > 0)
                return false;
            return true;
        }

        public int Result()
        {
            return m_Result;
        }

        public int GetAddCallCount()
        {
            return m_AddCallCount;
        }
    }
}
