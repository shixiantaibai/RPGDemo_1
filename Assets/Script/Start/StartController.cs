using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public TweenScale startpanelTween;
    public TweenScale loginpanelTween;
    public TweenScale registerpanelTween;
    public UIInput usernameInputLogin;
    public UIInput passwordInputLogin;
    //r_un_InputLogin=注册面板上的用户名输入框
    public UIInput r_un_Input;
    //r_ps_Input=注册面板上的密码输入框
    public UIInput r_ps_Input;
    //r_ps_qr_Input=注册面板上的确认密码输入框
    public UIInput r_ps_qr_Input;
    public UILabel usernameLabelStart;
    public static string username;
    public static string password;

    public void OnUsernameClick() {
        //切换到登录面板
        startpanelTween.PlayForward();
        StartCoroutine(HidPanel(startpanelTween.gameObject));
        loginpanelTween.gameObject.SetActive(true);
        loginpanelTween.PlayForward();
    }
    public void OnServerClick() { }
    public void OnEnterGameClick() {
        //1.连接服务器，验证用户名与服务器
    }

    //隐藏面板
    IEnumerator HidPanel(GameObject go) {
        yield return new WaitForSeconds(0.4f);
        go.SetActive(false);
    }
    //登录按钮事件处理
    public void OnLoginClick() {
        //得到用户名和密码，存储起来
        username = usernameInputLogin.value;
        password = passwordInputLogin.value;
        loginpanelTween.PlayReverse();
        StartCoroutine(HidPanel(loginpanelTween.gameObject));
        startpanelTween.gameObject.SetActive(true);
        startpanelTween.PlayReverse();
        usernameLabelStart.text = username;
    }
    //注册按钮事件处理
    public void OnRegisterShowClick() {
        loginpanelTween.PlayReverse();
        StartCoroutine(HidPanel(loginpanelTween.gameObject));
        registerpanelTween.gameObject.SetActive(true);
        registerpanelTween.PlayForward();
    }
    //关闭按钮事件处理
    public void OnLoginCloseClick() {
        loginpanelTween.PlayReverse();
        StartCoroutine(HidPanel(loginpanelTween.gameObject));
        startpanelTween.gameObject.SetActive(true);
        startpanelTween.PlayReverse();
    }
    //取消按钮事件处理
    public void OnCancelClick() {
        registerpanelTween.PlayReverse();
        StartCoroutine(HidPanel(registerpanelTween.gameObject));
        loginpanelTween.gameObject.SetActive(true);
        loginpanelTween.PlayForward();
    }
    //注册并登录事件处理
    public void OnRegisterAndLoginClick() {
        //1.本地服务器连接校验
        //2.连接失败给出提示
        //3.连接成功
        username = r_un_Input.value;
        password = r_ps_Input.value;
        registerpanelTween.PlayReverse();
        StartCoroutine(HidPanel(registerpanelTween.gameObject));
        startpanelTween.gameObject.SetActive(true);
        startpanelTween.PlayReverse();
        usernameLabelStart.text = username;
    }
    //注册界面关闭按钮事件处理
    public void OnRegisterCloseClick() {
        OnCancelClick();
    }
}
