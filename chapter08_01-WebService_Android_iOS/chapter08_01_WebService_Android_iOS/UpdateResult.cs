﻿using System;

namespace chapter08_01_WebService_Android_iOS
{
    public class UpdateResult
    {
        private String result;
        private String id;
        private String errorDesc;

        public String Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }

        public String Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string ErrorDesc
        {
            get
            {
                return errorDesc;
            }

            set
            {
                errorDesc = value;
            }
        }
    }
}
