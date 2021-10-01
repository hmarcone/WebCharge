const PROXY_CONFIG = [
  {
    context: ['/api'],
    //target: 'http://localhost:59231/',
    //target: 'http://localhost:58479/',
    target: 'http://localhost:57651/',
    secure: false,
    logLevel: 'debug'
  }
];

module.exports = PROXY_CONFIG;
