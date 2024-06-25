1. Web API solution: 
- "MarketingScheduler"" .Net 8 Web Api
- "Application" (business layer) - .Net 8 Class library 
- "DataAcces" (db layer) .Net 8 Class library 
2. DB is SQLite. To read from solution maybe you will need SQLite Server Compact Toolbox

3. Files: 
- Sends.txt - file to log sended Campaigns
- campaigns.db - SQLite Db file with Customers

4.Not finished: 
- HangFire concurency problem
- Priority Campaigns settings
- Unit tests