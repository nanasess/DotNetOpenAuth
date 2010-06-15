﻿//-----------------------------------------------------------------------
// <copyright file="WebServerRequest.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOpenAuth.OAuthWrap.Messages.WebServer {
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using System.Linq;
	using System.Text;
	using DotNetOpenAuth.Messaging;

	public class WebServerRequest : EndUserAuthorizationRequest {
		/// <summary>
		/// The type of message.
		/// </summary>
		[MessagePart(Protocol.type, IsRequired = true)]
		private const string Type = "web_server";

		/// <summary>
		/// Initializes a new instance of the <see cref="EndUserAuthorizationRequest"/> class.
		/// </summary>
		/// <param name="authorizationEndpoint">The Authorization Server's user authorization URL to direct the user to.</param>
		/// <param name="version">The protocol version.</param>
		internal WebServerRequest(Uri authorizationEndpoint, Version version)
			: base(authorizationEndpoint, version) {
			Contract.Requires<ArgumentNullException>(authorizationEndpoint != null);
			Contract.Requires<ArgumentNullException>(version != null);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EndUserAuthorizationRequest"/> class.
		/// </summary>
		/// <param name="authorizationServer">The authorization server.</param>
		internal WebServerRequest(AuthorizationServerDescription authorizationServer)
			: base(authorizationServer) {
			Contract.Requires<ArgumentNullException>(authorizationServer != null);
			Contract.Requires<ArgumentException>(authorizationServer.Version != null);
			Contract.Requires<ArgumentException>(authorizationServer.AuthorizationEndpoint != null);
		}
	}
}