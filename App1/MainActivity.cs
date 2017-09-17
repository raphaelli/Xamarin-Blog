using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using NS96;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //获取WebView对象
            var webView = FindViewById<WebView>(Resource.Id.webView1);

            //申明WebView的配置
            WebSettings settings = webView.Settings;

            //允许执行JS
            settings.JavaScriptEnabled = true;

            //设置可以通过js打开窗口
            settings.JavaScriptCanOpenWindowsAutomatically = true;

            //创建webView客户端类
            var webc = new MyCommWebClient();

            //设置WebVIew客户端
            webView.SetWebViewClient(webc);

            webView.LoadUrl("https://ns96.com");
        }
    }
    class MyCommWebClient : WebViewClient
    {
        //重写加载方法
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            //使用文本空间加载
            view.LoadUrl(url);
            return true;
        }
    }
}

