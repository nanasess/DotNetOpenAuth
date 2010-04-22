﻿//-----------------------------------------------------------------------
// <copyright file="ClientAccountUsernamePasswordRequest.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOpenAuth.OAuthWrap.Messages {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using DotNetOpenAuth.Messaging;

	/// <summary>
	/// A request for an access token for a client application that has its
	/// own (non-user affiliated) client name and password.
	/// </summary>
	/// <remarks>
	/// This is somewhat analogous to 2-legged OAuth.
	/// </remarks>
	internal class ClientAccountUsernamePasswordRequest : MessageBase {
		/// <summary>
		/// Initializes a new instance of the <see cref="ClientAccountUsernamePasswordRequest"/> class.
		/// </summary>
		/// <param name="authorizationServer">The authorization server.</param>
		/// <param name="version">The version.</param>
		internal ClientAccountUsernamePasswordRequest(Uri authorizationServer, Version version)
			: base(version, MessageTransport.Direct, authorizationServer) {
			this.HttpMethods = HttpDeliveryMethods.PostRequest;
		}

		/// <summary>
		/// Gets or sets the account name.
		/// </summary>
		/// <value>The name on the account.</value>
		[MessagePart(Protocol.wrap_name, IsRequired = true, AllowEmpty = false)]
		internal string Name { get; set; }

		/// <summary>
		/// Gets or sets the user's password.
		/// </summary>
		/// <value>The password.</value>
		[MessagePart(Protocol.wrap_password, IsRequired = true, AllowEmpty = false)]
		internal string Password { get; set; }

		/// <summary>
		/// Gets or sets an optional authorization scope as defined by the Authorization Server.
		/// </summary>
		[MessagePart(Protocol.wrap_scope, IsRequired = false, AllowEmpty = true)]
		internal string Scope { get; set; }

		/// <summary>
		/// Checks the message state for conformity to the protocol specification
		/// and throws an exception if the message is invalid.
		/// </summary>
		/// <remarks>
		/// 	<para>Some messages have required fields, or combinations of fields that must relate to each other
		/// in specialized ways.  After deserializing a message, this method checks the state of the
		/// message to see if it conforms to the protocol.</para>
		/// 	<para>Note that this property should <i>not</i> check signatures or perform any state checks
		/// outside this scope of this particular message.</para>
		/// </remarks>
		/// <exception cref="ProtocolException">Thrown if the message is invalid.</exception>
		protected override void EnsureValidMessage() {
			base.EnsureValidMessage();
			ErrorUtilities.VerifyProtocol(this.Recipient.IsTransportSecure(), OAuthWrapStrings.HttpsRequired);
		}
	}
}