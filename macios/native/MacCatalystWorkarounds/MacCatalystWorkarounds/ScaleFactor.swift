//
//  ScaleFactor.swift
//  ReaditLite
//
//  Created by Jeremy Powell on 18/08/2025.
//  Copyright © 2025 Apple. All rights reserved.
//

import ObjectiveC
import Foundation
import UIKit

@objc(MacCatalystWorkarounds)
public class MacCatalystWorkarounds : NSObject
{
    @objc
    public static func overrideCatalystScaleFactor() {
        guard let sceneViewClass = NSClassFromString("UINSSceneView") as? NSObject.Type else {
            return
        }
        if sceneViewClass.instancesRespond(to: NSSelectorFromString("scaleFactor")) {
            // old
            swizzleInstanceMethod(
                class: sceneViewClass,
                originalSelector: NSSelectorFromString("scaleFactor"),
                swizzledSelector: #selector(NSObject.swizzle_scaleFactor)
            )
        } else {
            // macOS 11.3 Beta 3+
            swizzleInstanceMethod(
                class: sceneViewClass,
                originalSelector: NSSelectorFromString("sceneToSceneViewScaleFactor"),
                swizzledSelector: #selector(NSObject.swizzle_scaleFactor)
            )
            swizzleInstanceMethod(
                class: sceneViewClass,
                originalSelector: NSSelectorFromString("fixedSceneToSceneViewScaleFactor"),
                swizzledSelector: #selector(NSObject.swizzle_scaleFactor2)
            )
            swizzleInstanceMethod(
                class: NSClassFromString("UINSSceneContainerView"),
                originalSelector: NSSelectorFromString("sceneToSceneViewScaleForLayout"),
                swizzledSelector: #selector(NSObject.swizzle_scaleFactor3)
            )
        }
    }
}
    
@objc extension NSObject {
    func swizzle_scaleFactor() -> CGFloat { 1 }
    func swizzle_scaleFactor2() -> CGFloat { 1 }
    func swizzle_scaleFactor3() -> CGFloat { 1 }
}
