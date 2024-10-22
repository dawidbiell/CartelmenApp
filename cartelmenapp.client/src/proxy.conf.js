const { env } = require('process');

const target = 'http://localhost:5000'

// env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
//     env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7220';

const PROXY_CONFIG = [
  {
    context: [
      "/building",
      "/api"
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
