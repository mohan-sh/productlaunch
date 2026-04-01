<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProductLaunch.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<style>
  @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600;700;800&display=swap');

  body { font-family: 'Poppins', sans-serif; margin: 0; }

  /* NAV */
  .nav-bar { display:flex; justify-content:space-between; align-items:center; padding:18px 60px; background:#fff; box-shadow:0 2px 10px rgba(0,0,0,0.08); position:sticky; top:0; z-index:100; }
  .nav-logo { font-size:1.4rem; font-weight:800; color:#1a73e8; }
  .nav-links a { margin-left:24px; text-decoration:none; color:#444; font-weight:500; }
  .nav-links a:hover { color:#1a73e8; }
  .btn-nav { background:#1a73e8; color:#fff !important; padding:8px 20px; border-radius:25px; }
  .btn-nav:hover { background:#1558b0; }

  /* HERO */
  .hero { background:linear-gradient(135deg,#1a73e8 0%,#0d47a1 100%); color:#fff; padding:100px 60px; text-align:center; }
  .hero h1 { font-size:3.5rem; font-weight:800; margin:0 0 16px; }
  .hero p { font-size:1.25rem; opacity:.9; margin:0 0 32px; }
  .badges { margin-bottom:32px; }
  .badge { display:inline-block; background:rgba(255,255,255,0.2); border:1px solid rgba(255,255,255,0.4); color:#fff; padding:6px 16px; border-radius:20px; font-size:.8rem; margin:4px; }
  .btn-hero { background:#fff; color:#1a73e8; padding:14px 36px; border-radius:30px; font-size:1.1rem; font-weight:700; text-decoration:none; transition:.2s; }
  .btn-hero:hover { background:#e8f0fe; color:#1a73e8; }

  /* FEATURES */
  .section { padding:80px 60px; text-align:center; }
  .section h2 { font-size:2rem; font-weight:700; margin-bottom:48px; color:#1a1a2e; }
  .cards { display:flex; flex-wrap:wrap; gap:24px; justify-content:center; }
  .card { background:#fff; border-radius:16px; box-shadow:0 4px 20px rgba(0,0,0,0.08); padding:36px 28px; width:220px; transition:.2s; }
  .card:hover { transform:translateY(-6px); box-shadow:0 8px 30px rgba(0,0,0,0.12); }
  .card-icon { font-size:2.5rem; margin-bottom:16px; }
  .card h3 { font-size:1rem; font-weight:600; color:#1a1a2e; margin:0; }

  /* TOOLS */
  .tools-section { background:#f8f9ff; padding:80px 60px; text-align:center; }
  .tools-section h2 { font-size:2rem; font-weight:700; margin-bottom:48px; color:#1a1a2e; }
  .tools { display:flex; flex-wrap:wrap; gap:20px; justify-content:center; }
  .tool { background:#fff; border-radius:12px; padding:20px 32px; font-weight:600; font-size:1rem; color:#1a73e8; box-shadow:0 2px 12px rgba(0,0,0,0.07); }

  /* TESTIMONIALS */
  .testimonials { padding:80px 60px; text-align:center; background:#fff; }
  .testimonials h2 { font-size:2rem; font-weight:700; margin-bottom:48px; color:#1a1a2e; }
  .testi-cards { display:flex; gap:24px; justify-content:center; flex-wrap:wrap; }
  .testi-card { background:#f8f9ff; border-radius:16px; padding:32px; max-width:360px; text-align:left; box-shadow:0 2px 12px rgba(0,0,0,0.06); }
  .testi-card p { color:#444; font-size:.95rem; line-height:1.7; margin:0 0 16px; }
  .testi-card span { font-weight:600; color:#1a73e8; font-size:.9rem; }

  /* CTA */
  .cta-section { background:linear-gradient(135deg,#1a73e8,#0d47a1); color:#fff; padding:80px 60px; text-align:center; }
  .cta-section h2 { font-size:2.2rem; font-weight:700; margin:0 0 16px; }
  .cta-section p { font-size:1.1rem; opacity:.9; margin:0 0 32px; }
  .btn-cta { background:#fff; color:#1a73e8; padding:14px 40px; border-radius:30px; font-size:1.1rem; font-weight:700; text-decoration:none; transition:.2s; }
  .btn-cta:hover { background:#e8f0fe; }

  /* FOOTER */
  .footer { background:#1a1a2e; color:#aaa; text-align:center; padding:28px; font-size:.85rem; }
  .footer a { color:#aaa; margin:0 12px; text-decoration:none; }
  .footer a:hover { color:#fff; }

  @media(max-width:768px) {
    .nav-bar { padding:16px 20px; }
    .hero { padding:60px 20px; }
    .hero h1 { font-size:2.2rem; }
    .section, .tools-section, .testimonials, .cta-section { padding:60px 20px; }
  }
</style>

<!-- NAV -->
<nav class="nav-bar">
  <div class="nav-logo">⚙️ DevOps coaching</div>
  <div class="nav-links">
    <a href="About.aspx">About</a>
    <a href="Contact.aspx">Contact</a>
    <a href="SignUp.aspx" class="btn-nav">Sign Up</a>
  </div>
</nav>

<!-- HERO -->
<section class="hero">
  <h1>Master DevOps</h1>
  <p>Step-by-step program to become a DevOps Engineer</p>
  <div class="badges">
    <span class="badge">🎯 Beginner Friendly</span>
    <span class="badge">🛠️ Hands-on</span>
    <span class="badge">💼 Job Ready</span>
  </div>
  <a href="SignUp.aspx" class="btn-hero">Start Learning &raquo;</a>
</section>

<!-- FEATURES -->
<section class="section">
  <h2>What You'll Learn</h2>
  <div class="cards">
    <div class="card"><div class="card-icon">🧪</div><h3>Hands-on Labs</h3></div>
    <div class="card"><div class="card-icon">🔄</div><h3>CI/CD Pipelines</h3></div>
    <div class="card"><div class="card-icon">☁️</div><h3>Cloud & Kubernetes</h3></div>
    <div class="card"><div class="card-icon">🚀</div><h3>Real-world Projects</h3></div>
  </div>
</section>

<!-- TOOLS -->
<section class="tools-section">
  <h2>Tools You'll Master</h2>
  <div class="tools">
    <div class="tool">🐳 Docker</div>
    <div class="tool">☸️ Kubernetes</div>
    <div class="tool">☁️ AWS</div>
    <div class="tool">🏗️ Terraform</div>
    <div class="tool">⚙️ Jenkins</div>
  </div>
</section>

<!-- TESTIMONIALS -->
<section class="testimonials">
  <h2>What Our Students Say</h2>
  <div class="testi-cards">
    <div class="testi-card">
      <p>"This program completely transformed my career. The hands-on labs made complex DevOps concepts easy to grasp."</p>
      <span>— Alex M., DevOps Engineer</span>
    </div>
    <div class="testi-card">
      <p>"From zero to deploying on Kubernetes in 8 weeks. The real-world projects gave me the confidence to land my first DevOps role."</p>
      <span>— Priya S., Cloud Engineer</span>
    </div>
  </div>
</section>

<!-- CTA -->
<section class="cta-section">
  <h2>Ready to Start Your DevOps Journey?</h2>
  <p>Join thousands of engineers who've already transformed their careers.</p>
  <a href="SignUp.aspx" class="btn-cta">Join Now &raquo;</a>
</section>

<!-- FOOTER -->
<footer class="footer">
  <p>
    &copy; 2026 DevOps School &nbsp;|&nbsp;
    <a href="About.aspx">About</a>
    <a href="Contact.aspx">Contact</a>
    <a href="SignUp.aspx">Sign Up</a>
  </p>
</footer>

</asp:Content>