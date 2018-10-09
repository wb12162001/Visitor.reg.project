// File: VR_VISITModel.cs
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
	/// <para>VR_VISITModel Object</para>
	/// <para>Summary description for VR_VISITModel.</para>
	/// <para><see cref="member"/></para>
	/// <remarks></remarks>
	/// </summary>
	[TableMappingAttribute(tableName: "VR_VISIT", likeQueryFields: "*")]
	public class VR_VISITModel : BaseModel
	{
		
		#region Public Properties
		
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ID*"), Required]
		public int ID
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string SiteName
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string VisitorName
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string FromCompany
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string Host
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string BarCode
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public DateTime SignIn_DateTime
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public DateTime SignOut_DateTime
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public byte EMAIL_Status
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public byte OUT_Status
		{
			get;
			set;
		}
		#endregion
	}
}