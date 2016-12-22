﻿using System;
using System.Runtime.Serialization;

namespace AutoReservation.BusinessLayer
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("Entity not found")
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}