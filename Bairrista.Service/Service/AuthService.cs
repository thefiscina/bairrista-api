﻿using Bairrista.Dominio.SeedWork;
using Bairrista.Service.Model;
using Microsoft.Extensions.Options;
using System;

namespace Bairrista.Dominio.Service
{
    public interface IAuthService
    {
        AuthResponse Login(AuthRequest request);
    }

    public class AuthService : IAuthService
    {
        IUsuarioDomain _usuarioDomain;
        TokenSettings _tokenSettings;
        public AuthService(IOptions<TokenSettings> tokenSetting, DashboardContext context)
        {
            _usuarioDomain = new UsuarioDomain(context);
            _tokenSettings = tokenSetting.Value;
        }

        public AuthResponse Login(AuthRequest request)
        {
            Usuario _usuario = _usuarioDomain.ObterPorLogin(request.login);

            if (_usuario == null)
                throw new Exception("Usuário não encontrado");

            if (!Auth.VerificarSenhaHash(request.senha))
                throw new Exception("Senha Inválida");

            AuthResponse authResponse = new AuthResponse();
            authResponse.access_token = Auth.GerarToken(_usuario.Id.ToString(), _usuario.Token, _tokenSettings.Secret, _tokenSettings.Seconds, _tokenSettings.Audience);
            authResponse.nome = _usuario.Nome;            
            return authResponse;
        }
    }
}