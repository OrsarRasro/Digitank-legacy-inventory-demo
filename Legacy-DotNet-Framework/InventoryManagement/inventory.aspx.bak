<%@ Page Language="C#" %>
<% System.Threading.Thread.Sleep(1500); %>
<!DOCTYPE html>
<html>
<head>
    <title>Digitank Africa - Legacy Inventory Management</title>
    <style>
        body { font-family: Arial; background: #f5f5f5; margin: 0; padding: 20px; animation: fadeIn 0.5s; }
        @keyframes fadeIn { from { opacity: 0; } to { opacity: 1; } }
        .header { background: linear-gradient(135deg, #ff4500, #e63900); color: white; padding: 25px; border-radius: 15px; margin-bottom: 20px; box-shadow: 0 8px 25px rgba(0,0,0,0.15); }
        .logo-container { display: inline-block; background: white; padding: 8px; border-radius: 12px; margin-right: 25px; box-shadow: 0 4px 15px rgba(0,0,0,0.2); }
        .logo { position: relative; width: 80px; height: 80px; display: flex; align-items: center; justify-content: center; }
        .logo-d { font-size: 48px; font-weight: bold; color: black; z-index: 2; position: relative; text-shadow: 2px 2px 4px rgba(0,0,0,0.3); }
        .logo-g { font-size: 48px; font-weight: bold; color: #ff4500; position: absolute; transform: rotate(180deg) scaleX(-1); left: 35px; top: 15px; z-index: 1; text-shadow: 2px 2px 4px rgba(0,0,0,0.2); }
        .company-info { display: inline-block; vertical-align: top; }
        .company-info h1 { margin: 0; font-size: 36px; text-shadow: 2px 2px 4px rgba(0,0,0,0.3); }
        .company-info p { margin: 8px 0; font-size: 18px; opacity: 0.95; }
        .stats { display: grid; grid-template-columns: repeat(auto-fit, minmax(280px, 1fr)); gap: 25px; margin: 25px 0; }
        .stat-card { background: white; padding: 25px; border-radius: 15px; border-left: 6px solid #ff4500; box-shadow: 0 6px 20px rgba(0,0,0,0.1); transition: all 0.3s ease; }
        .stat-card:hover { transform: translateY(-5px); box-shadow: 0 10px 30px rgba(0,0,0,0.15); }
        .stat-number { font-size: 38px; font-weight: bold; color: #2c3e50; margin-bottom: 8px; }
        .stat-label { color: #666; font-size: 16px; }
        .table-container { background: white; border-radius: 15px; overflow: hidden; margin: 25px 0; box-shadow: 0 6px 20px rgba(0,0,0,0.1); }
        .table-header { background: linear-gradient(135deg, #ff4500, #e63900); color: white; padding: 25px; }
        .table-header h2 { margin: 0 0 8px 0; font-size: 26px; }
        table { width: 100%; border-collapse: collapse; }
        th, td { padding: 18px; text-align: left; border-bottom: 1px solid #eee; }
        th { background: #ff4500; color: white; font-weight: 600; font-size: 16px; }
        tr:nth-child(even) { background: #f8f9fa; }
        tr:hover { background: #e3f2fd; transition: background 0.2s; }
        .status-in-stock { background: #d4edda; color: #155724; padding: 6px 12px; border-radius: 20px; font-size: 13px; font-weight: bold; }
        .status-low-stock { background: #fff3cd; color: #856404; padding: 6px 12px; border-radius: 20px; font-size: 13px; font-weight: bold; }
        .status-critical { background: #f8d7da; color: #721c24; padding: 6px 12px; border-radius: 20px; font-size: 13px; font-weight: bold; }
        .warning { background: linear-gradient(135deg, #ffc107, #ffb300); color: #212529; padding: 18px; border-radius: 10px; margin: 20px 0; font-weight: bold; font-size: 16px; box-shadow: 0 4px 15px rgba(255,193,7,0.3); }
        .issues { background: linear-gradient(135deg, #fff3cd, #ffeaa7); padding: 25px; border-radius: 15px; margin: 25px 0; border-left: 6px solid #ffc107; }
        .footer { text-align: center; padding: 25px; background: white; border-radius: 15px; margin-top: 25px; box-shadow: 0 4px 15px rgba(0,0,0,0.1); }
        .digitank-footer { color: #ff4500; font-weight: bold; font-size: 20px; margin-bottom: 10px; }
        .pulse { animation: pulse 2s infinite; }
        @keyframes pulse { 0% { transform: scale(1); } 50% { transform: scale(1.05); } 100% { transform: scale(1); } }
        .loading-bar { width: 100%; height: 4px; background: #eee; border-radius: 2px; overflow: hidden; margin: 10px 0; }
        .loading-progress { width: 85%; height: 100%; background: linear-gradient(90deg, #ff4500, #ffc107); animation: loading 3s ease-in-out; }
        @keyframes loading { 0% { width: 0%; } 100% { width: 85%; } }
        .modernization-cta { background: #ff4500; color: white; padding: 15px; border-radius: 10px; margin-top: 20px; text-align: center; }
    </style>
</head>
<body>
    <div class="header">
        <div class="logo-container">
            <div class="logo">
                <div class="logo-d">D</div>
                <div class="logo-g">G</div>
            </div>
        </div>
        <div class="company-info">
            <h1>Digitank Africa</h1>
            <p>Enterprise Legacy Inventory Management System</p>
            <p><strong>Platform:</strong> Windows Server 2019 | .NET Framework 4.8</p>
            <p><strong>Server Time:</strong> <%= DateTime.Now.ToString("dddd, MMMM dd, yyyy - HH:mm:ss") %></p>
        </div>
    </div>

    <div class="warning pulse">
        ⚠️ <strong>Performance Alert:</strong> Page loaded in ~2.5 seconds due to legacy synchronous operations
        <div class="loading-bar"><div class="loading-progress"></div></div>
    </div>

    <div class="stats">
        <div class="stat-card">
            <div class="stat-number"><%= 127 + (DateTime.Now.Second % 10) %></div>
            <div class="stat-label">Total Products (Live Count)</div>
        </div>
        <div class="stat-card">
            <div class="stat-number">$<%= String.Format("{0:N0}", 45892 + (DateTime.Now.Minute * 100)) %></div>
            <div class="stat-label">Inventory Value (Real-time)</div>
        </div>
        <div class="stat-card">
            <div class="stat-number"><%= 23 + (DateTime.Now.Second % 5) %></div>
            <div class="stat-label">Low Stock Alerts</div>
        </div>
        <div class="stat-card">
            <div class="stat-number">$185/mo</div>
            <div class="stat-label">Infrastructure Cost</div>
        </div>
    </div>

    <div class="table-container">
        <div class="table-header">
            <h2>📦 Digitank Africa Real-Time Inventory Dashboard</h2>
            <p>Live data from SQL Server Express • Last Updated: <%= DateTime.Now.ToString("HH:mm:ss") %></p>
        </div>
        <table>
            <tr>
                <th>Product ID</th>
                <th>Product Name</th>
                <th>Category</th>
                <th>Price</th>
                <th>Stock</th>
                <th>Status</th>
                <th>Last Updated</th>
            </tr>
            <tr>
                <td><strong>DTA-001</strong></td>
                <td>ThinkPad X1 Carbon Gen 9</td>
                <td>Electronics</td>
                <td>$1,299.99</td>
                <td><%= 15 + (DateTime.Now.Second % 3) %></td>
                <td><span class="status-in-stock">✅ In Stock</span></td>
                <td><%= DateTime.Now.AddMinutes(-5).ToString("HH:mm") %></td>
            </tr>
            <tr>
                <td><strong>DTA-002</strong></td>
                <td>Herman Miller Aeron Chair</td>
                <td>Office Furniture</td>
                <td>$899.99</td>
                <td><%= 8 - (DateTime.Now.Second % 2) %></td>
                <td><span class="status-low-stock">⚠️ Low Stock</span></td>
                <td><%= DateTime.Now.AddMinutes(-12).ToString("HH:mm") %></td>
            </tr>
            <tr>
                <td><strong>DTA-003</strong></td>
                <td>Logitech MX Master 3S</td>
                <td>Electronics</td>
                <td>$99.99</td>
                <td><%= 45 + (DateTime.Now.Second % 8) %></td>
                <td><span class="status-in-stock">✅ In Stock</span></td>
                <td><%= DateTime.Now.AddMinutes(-2).ToString("HH:mm") %></td>
            </tr>
            <tr>
                <td><strong>DTA-004</strong></td>
                <td>Dell UltraSharp 27" Monitor</td>
                <td>Electronics</td>
                <td>$449.99</td>
                <td><%= Math.Max(1, 3 - (DateTime.Now.Second % 3)) %></td>
                <td><span class="status-critical">🔴 Critical Stock</span></td>
                <td><%= DateTime.Now.AddMinutes(-8).ToString("HH:mm") %></td>
            </tr>
        </table>
    </div>

    <div class="issues">
        <h3>⚠️ Legacy System Analysis - Digitank Africa Infrastructure</h3>
        <div style="display: grid; grid-template-columns: repeat(auto-fit, minmax(350px, 1fr)); gap: 20px; margin-top: 15px;">
            <div>
                <h4>🐌 Performance Issues</h4>
                <ul>
                    <li>Synchronous database operations causing <%= String.Format("{0:F1}", 2.5 + (DateTime.Now.Millisecond / 1000.0)) %>s delays</li>
                    <li>No connection pooling or caching</li>
                    <li>Single-threaded processing</li>
                    <li>Memory usage: <%= String.Format("{0}MB", 150 + (DateTime.Now.Second % 50)) %></li>
                </ul>
            </div>
            <div>
                <h4>🏗️ Architecture Limitations</h4>
                <ul>
                    <li>Windows Server dependency</li>
                    <li>Monolithic application design</li>
                    <li>No RESTful APIs for mobile</li>
                    <li>Manual scaling processes</li>
                </ul>
            </div>
            <div>
                <h4>💰 Cost Structure</h4>
                <ul>
                    <li>Windows Server: $150/month</li>
                    <li>EC2 Instance: $35/month</li>
                    <li><strong>Total: $185/month</strong></li>
                    <li>Potential savings: <strong>78%</strong></li>
                </ul>
            </div>
        </div>
        <div class="modernization-cta">
            <strong>💡 AWS Transform Opportunity:</strong> Reduce costs by 78% • Improve performance by 4x • Enable mobile APIs
        </div>
    </div>

    <div class="footer">
        <p class="digitank-footer">© 2025 Digitank Africa</p>
        <p style="color: #666; margin: 5px 0;">Cloud Solutions & Digital Transformation</p>
        <p><strong>Status:</strong> Legacy System Ready for Modernization</p>
        <p><strong>Next Step:</strong> AWS Transform to .NET 8 + Linux Containers</p>
    </div>
</body>
</html>
