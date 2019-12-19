using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nipuna.Model;

namespace Nipuna.DataAccess.Payments
{
    public class PaymentDataAccess
    {
        // get all payment deatails
        public static IEnumerable<Payment> getPayment()
        {
            using (var db = new NipunaDataContext())
            {
                var record = db.Payments.ToList();
                return record;
            }
        }

        // add payment detail
        public static bool addPayment(Payment payment)
        {
            using (var db = new NipunaDataContext())
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return true;
            }
        }

        // edit payment details
        public static bool editPayment(Payment payment)
        {
            using (var db = new NipunaDataContext())
            {
                var record = db.Payments.SingleOrDefault(x => x.InvoiceNo == payment.InvoiceNo);
                record.RegistrationId = payment.RegistrationId;
                record.StudentName = payment.StudentName;
                record.CourseId = payment.CourseId;
                record.CourseName = payment.CourseName;
                record.LecturerId = payment.LecturerId;
                record.LectuerName = payment.LectuerName;
                record.Fee = payment.Fee;
                record.Amount = payment.Amount;
                record.Balance = payment.Balance;
                record.PaidDate = payment.PaidDate;

                db.SaveChanges();
                return true;
            }
        }

        // delete payment details 
        public static bool deletePayment(Payment payment)
        {
            using (var db = new NipunaDataContext())
            {
                var record = db.Payments.SingleOrDefault(x => x.InvoiceNo == payment.InvoiceNo);
                db.Payments.Remove(record);

                db.SaveChanges();
                return true;
            }
        }

        // generate new invoice Id
        public static string generateInvoiceId()
        {
            using (var db = new NipunaDataContext())
            {
                var record = db.Payments.Max(c => c.InvoiceNo);
                if (record == null)
                {
                    record = "INV000";
                    return record;
                }
                else
                {
                    return record;
                }
            }
        }

        // find payment by Invoice Id
        public static Payment findByInvoiceId(string Id)
        {
            using (var db = new NipunaDataContext())
            {
                var record = db.Payments.SingleOrDefault(x => x.InvoiceNo == Id);
                return record;
            }
        }

        //filter payment grid(invoices)
        public static IEnumerable<Payment> filterPayment(string search)
        {
            using (var db = new NipunaDataContext())
            {
                var record = db.Payments.Where(x => x.RegistrationId.StartsWith(search)
                                                || x.StudentName.StartsWith(search)
                                                || x.CourseId.StartsWith(search)
                                                || x.CourseName.StartsWith(search)
                                                || x.InvoiceNo.StartsWith(search)
                                                || x.PaidDate.ToString().StartsWith(search)
                                                || x.Invoicedate.ToString().StartsWith(search)).ToList();
                return record;
            }
        }

       
        //public static string checkPaymentRecord(string registrationId)
        //{
        //    using (var db = new NipunaDataContext())
        //    {
        //        var record = db.Payments.SingleOrDefault(x => x.RegistrationId == registrationId);
        //        if (record != null)
        //        {
        //            var result = "";
        //            result = "Not null";
        //            return result;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
        // check any payment record available with the given registration id and course id
        public static IEnumerable<Payment> checkRegistrationId(string registrationId)
        {
            using (var db = new NipunaDataContext())
            {
                var record = db.Payments.Where(x => x.RegistrationId == registrationId).ToList();
                if (record.Count != 0)
                {
                    return record;
                }
                else
                {
                    return null;
                }
            }
        }

        public static Payment getLastRecord(string registrationtId, string courseId) 
        {
            using (var db = new NipunaDataContext()) 
            {
                var record = db.Payments.Where(x => x.RegistrationId == registrationtId && x.CourseId == courseId)
                                        .OrderByDescending(x => x.Invoicedate).FirstOrDefault();
                return record;
            }
        }

        // get last record for attendance process
        public static Payment checkLastRecord(string registrationId, string courseId) 
        {
            using (var db = new NipunaDataContext()) 
            {
                var record = db.Payments.Where(x => x.RegistrationId == registrationId && x.CourseId == courseId && x.IsRemoved==false)
                                        .OrderByDescending(x => x.Invoicedate).FirstOrDefault();
                return record;
            }
        }
    }
}
