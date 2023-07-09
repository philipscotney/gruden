const { env } = require('process');

const target = env.ASPNETCORE_URLWITHPORT;  

const PROXY_CONFIG = [
  {
    context: [
      "/Person",
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
