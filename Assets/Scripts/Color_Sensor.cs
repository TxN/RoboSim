﻿using UnityEngine;
using System.Collections;

public class Color_Sensor : Block {
	public GameObject cm;
	public Texture2D gTex;
	public int size = 16;

	public Texture2D image;

	private RenderTexture RTex;
	void Start() {
		gTex = new Texture2D (size, size, TextureFormat.ARGB32, false);
		RTex = new RenderTexture (size, size,32,RenderTextureFormat.ARGB32);
	}


	public Texture2D RTImage(Camera cam) {

		RenderTexture.active = RTex;

		RenderTexture currentRT = RenderTexture.active;
		cam.targetTexture = RTex;
		RenderTexture.active = cam.targetTexture;
		cam.Render();
		Texture2D image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height);
		image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
		image.Apply();
		RenderTexture.active = currentRT;

		gTex = image;
		gTex.Apply ();
		return image;

	}

	public float GetBrightness() {

		int pixelCount = 0;
		float val=0;
		Texture2D img = RTImage (cm.camera);
		for (int i = 0; i < img.height; i++) {
			for (int j = 0; j < img.width; j++) {
				pixelCount++;
				val += img.GetPixel(i,j).grayscale;
			}
		}
		val = val / pixelCount;
		return val;
	}

	public void Do() { // рендерим картинку для дальнейших измерений.
		image = RTImage (cm.camera);
	}

	public float GetR() { 
		int pixelCount = 0;
		float val=0;
		for (int i = 0; i < image.height; i++) {
			for (int j = 0; j < image.width; j++) {
				pixelCount++;
				val += image.GetPixel(i,j).r;
			}
		}
		val = val / pixelCount;
		return val;
	}

	public float GetG() { 
		int pixelCount = 0;
		float val=0;
		for (int i = 0; i < image.height; i++) {
			for (int j = 0; j < image.width; j++) {
				pixelCount++;
				val += image.GetPixel(i,j).g;
			}
		}
		val = val / pixelCount;
		//	Debug.Log (val);
		return val;
	}

	public float GetB() { 
		int pixelCount = 0;
		float val=0;
		for (int i = 0; i < image.height; i++) {
			for (int j = 0; j < image.width; j++) {
				pixelCount++;
				val += image.GetPixel(i,j).b;
			}
		}
		val = val / pixelCount;
		return val;
	}

	void OnGUI() {
		//GUI.DrawTexture (new Rect (200, 0, size, size),gTex);

	}

}
