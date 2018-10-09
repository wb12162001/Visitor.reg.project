// File: VR_SITESModel.cs
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
	/// <para>VR_SITESModel Object</para>
	/// <para>Summary description for VR_SITESModel.</para>
	/// <para><see cref="member"/></para>
	/// <remarks></remarks>
	/// </summary>
	[TableMappingAttribute(tableName: "VR_SITES", likeQueryFields: "*")]
	public class VR_SITESModel : BaseModel
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
		public string LOCATION
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string ADDRESS
		{
			get;
			set;
		}

        /// <summary>
        /// 
        /// </summary>
		public string ADMIN_EMAIL
		{
			get;
			set;
		}
		#endregion
	}
}