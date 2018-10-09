// File: TUSERModel.cs
// 2018/8/2: Bryant    Original Version
// 
// ===================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Reg.Common.Attributes;
using Visitor.Reg.Common.Enums;

namespace Visitor.Reg.Entity.Models
{
	/// <summary>
	/// <para>TUSERModel Object</para>
	/// <para>Summary description for TUSERModel.</para>
	/// <para><see cref="member"/></para>
	/// <remarks></remarks>
	/// </summary>
	[TableMappingAttribute(tableName: "TUSER", likeQueryFields: "*")]
	public class TUSERModel : BaseModel
	{
		
		#region Public Properties
		
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("USERID*"), Required]
		public string USERID
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string PASSID
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string FULLNAME
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string DESCRIPTION
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string LOCATION
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string PHONE
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string EXTNO
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string CELLPHONE
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string EMAIL
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string SHORTNAME
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string CLASS1
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string CLASS2
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string YammerId
		{
			get;
			set;
		}
		#endregion
	}
}