using System;

namespace chapter08_01_WebService_Android_iOS
{
    public class ListResult
    {
        public ListResult(object obj)
        {
            classResult = obj;
        }

        public ListResult()
        {
        }

        private object classResult;
        private PagingResult pagingResult;

        public object ClassResult
        {
            get
            {
                return classResult;
            }

            set
            {
                classResult = value;
            }
        }

        public PagingResult PagingResult
        {
            get
            {
                return pagingResult;
            }

            set
            {
                pagingResult = value;
            }
        }
    }
}
