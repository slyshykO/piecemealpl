use windows::{
    core::*, Win32::Foundation::*, Win32::Graphics::Gdi::*,
    Win32::System::LibraryLoader::GetModuleHandleA, Win32::UI::WindowsAndMessaging::*,
};

fn main() -> Result<()> {
    unsafe {
        let instance = GetModuleHandleA(None)?;
        let window_class = s!("Sample Window Class");

        let wc = WNDCLASSA {
            //hCursor: LoadCursorW(None, IDC_ARROW)?,
            hInstance: instance.into(),
            lpszClassName: window_class,

            //style: CS_HREDRAW | CS_VREDRAW,
            lpfnWndProc: Some(wndproc),
            ..Default::default()
        };

        let atom = RegisterClassA(&wc);
        debug_assert!(atom != 0);

        let hwnd = CreateWindowExA(
            WINDOW_EX_STYLE::default(),
            window_class,
            s!("Hello, world!"),
            WS_OVERLAPPEDWINDOW | WS_VISIBLE,
            CW_USEDEFAULT,
            CW_USEDEFAULT,
            CW_USEDEFAULT,
            CW_USEDEFAULT,
            None,
            None,
            None,
            None,
        )?;

        let _ = ShowWindow(hwnd, SW_NORMAL);
        let _ = UpdateWindow(hwnd);

        let mut message = MSG::default();

        while GetMessageA(&mut message, None, 0, 0).into() {
            let _ = TranslateMessage(&message);
            DispatchMessageA(&message);
        }

        Ok(())
    }
}

extern "system" fn wndproc(window: HWND, message: u32, wparam: WPARAM, lparam: LPARAM) -> LRESULT {
    unsafe {
        match message {
            //WM_PAINT => {
            //    println!("WM_PAINT");
            //    _ = ValidateRect(Some(window), None);
            //    LRESULT(0)
            //}
            WM_CREATE => {
                let _ = CreateWindowExA(
                    WS_EX_LEFT,
                    s!("BUTTON"),
                    s!("Click Me"),
                    WS_TABSTOP | WS_VISIBLE | WS_CHILD | WINDOW_STYLE(BS_DEFPUSHBUTTON as u32),
                    50,
                    50,
                    100,
                    30,
                    Some(window),
                    None,
                    None,
                    None,
                );
                LRESULT(0)
            }
            WM_DESTROY => {
                PostQuitMessage(0);
                LRESULT(0)
            }
            _ => DefWindowProcA(window, message, wparam, lparam),
        }
    }
}
